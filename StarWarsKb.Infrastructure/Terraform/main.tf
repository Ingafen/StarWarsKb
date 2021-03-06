terraform {
  required_providers {
    yandex = {
      source = "yandex-cloud/yandex"
    }
  }
  required_version = ">= 0.13"
}
provider "yandex" {
}
resource "yandex_vpc_network" "vpc" {
  name = var.vpc_name
}
resource "yandex_vpc_subnet" "public_subnet" {
  network_id     = yandex_vpc_network.vpc.id
  v4_cidr_blocks = var.subnet_cidr
  zone = var.vpc_zone
  name = var.subnet_name
}
resource "yandex_compute_instance" "bastion" {
  platform_id = "standard-v1"
  hostname = "bastion"
  name = "bastion"
  boot_disk {
    initialize_params {
      image_id = var.image_id
      size = 10
      type = "network-ssd"
    }
  }
  network_interface {
    subnet_id = yandex_vpc_subnet.public_subnet.id
    nat = true
  }
  resources {
    cores  = 2
    memory = 2
  }
  metadata = {
    user-data = templatefile("${path.module}/user_data.tftpl", {
      worker_ips = local.worker_ips
      master_ip = yandex_compute_instance.master.network_interface.0.ip_address
      master_name = yandex_compute_instance.master.hostname
      user_name = var.user_name
      public_key = file(var.public_key_path)
      private_key = file(var.private_key_path)
      sonar_node_name = yandex_compute_instance.sonarqubenode.hostname
      sonar_node_ip = yandex_compute_instance.sonarqubenode.network_interface.0.ip_address
      db_dev_name = var.db_dev_name,
      db_test_name = var.db_test_name,
      db_prod_name = var.db_prod_name,
      db_user = var.db_user,
      db_password = var.db_password,
      db_host = yandex_mdb_postgresql_cluster.db.host.0.fqdn
    } )
    ssh-keys = join(":", [var.user_name, file(var.public_key_path)])
  }
}
resource "yandex_compute_instance" "master" {
  platform_id = "standard-v1"
  hostname = "master"
  name = "master"
  boot_disk {
    initialize_params {
      image_id = var.image_id
      size = var.master_size
      type = "network-ssd"
    }
  }
  network_interface {
    subnet_id = yandex_vpc_subnet.public_subnet.id
    nat = true
  }
  resources {
    cores  = 2
    memory = 2
  }
  metadata = {
    user-data = "apt-get update"
    ssh-keys = join(":", [var.user_name, file(var.public_key_path)])
  }
}
resource "yandex_compute_instance" "sonarqubenode" {
  platform_id = "standard-v1"
  hostname = var.sonarqubenode
  name = var.sonarqubenode
  boot_disk {
    initialize_params {
      image_id = var.image_id
      size = 20
    }
  }
  network_interface {
    subnet_id = yandex_vpc_subnet.public_subnet.id
    nat = true
  }
  resources {
    cores  = 2
    memory = 6
  }
  metadata = {
    user-data = "apt-get update"
    ssh-keys = join(":", [var.user_name, file(var.public_key_path)])
  }
}
resource "yandex_compute_instance" "workers" {
  count = var.worker_nodes_count
  platform_id = "standard-v1"
  hostname = "worker${count.index}"
  name = "worker${count.index}"
  boot_disk {
    initialize_params {
      image_id = var.image_id
      size = var.worker_size
    }
  }
  network_interface {
    subnet_id = yandex_vpc_subnet.public_subnet.id
    nat = true
  }
  resources {
    cores  = 2
    memory = 2
  }
  metadata = {
    user-data = "apt-get update"
    ssh-keys = join(":", [var.user_name, file(var.public_key_path)])
  }
}
locals {
  worker_ips = tomap ({
    for inst in yandex_compute_instance.workers : inst.hostname => inst.network_interface.0.ip_address
  })
}
output "bastion_ip" {
  value = yandex_compute_instance.bastion.network_interface.0.nat_ip_address
  description = "IP of bastion host"
}

resource "yandex_mdb_postgresql_cluster" "db" {
  environment = "PRODUCTION"
  name        = "db"
  network_id  = yandex_vpc_network.vpc.id
  config {
    version = "14"
    resources {
      disk_size          = 10
      resource_preset_id = "b2.nano"
      disk_type_id = "network-ssd"
    }
  }
  database {
    name  = var.db_dev_name
    owner = var.db_user
  }
  database {
    name  = var.db_test_name
    owner = var.db_user
  }
  database {
    name  = var.db_prod_name
    owner = var.db_user
  }

  host {
    name = var.db_hostname
    zone = var.vpc_zone
  }
  user {
    name     = var.db_user
    password = var.db_password
  }
}

output "cluster_info" {
  value = yandex_mdb_postgresql_cluster.db.host
}