# vpc variables
variable "vpc_name" {
  type = string
  default = "Ingafen vpc"
}

variable "subnet_cidr" {
  type = list(string)
  default = [ "192.168.21.0/24" ]
}

variable "subnet_name" {
  type = string
  default = "public_subnet"
}

variable "vpc_zone" {
  type = string
  default = "ru-central1-a"
}

#Compute instance
variable "image_id" {
  type = string
  default = "fd8sc0f4358r8pt128gg"
  description = "ubuntu 20.04"
}

variable "user_name" {
  type = string
  default = "ubuntu"
}

variable "public_key_path" {
  type = string
  default = "~/.ssh/id_rsa.pub"
}

variable "private_key_path" {
  type = string
  default = "~/.ssh/id_rsa"
}

variable "worker_nodes_count" {
  type = number
  default = 2
}

variable "master_size" {
  type = number
  default = 20
  description = "Size of master storage"
}

variable "worker_size" {
  type = number
  default = 20
  description = "Size of worker storage"
}

variable "sonarqubenode" {
  type = string
  default = "sonarqubenode"
}

variable "region_id" {
  type = string
  default = "ru-central1"
}

variable "db_user" {
  default = "ingafen"
}

variable "db_password" {
  type = string
  default = "default_password"
  description = "DB password"
}

variable "db_hostname" {
  default = "ingafen_db"
}

variable "db_dev_name" {
  default = "swkb-dev-db"
}

variable "db_test_name" {
  default = "swkb-test-db"
}

variable "db_prod_name" {
  default = "swkb-prod-db"
}