# Star Wars knowledge base
Based on https://swapi.dev

This is my diploma app, that could be used as a sample.

This repository contains:
1. SWKB App code
2. IaaC scripts to build infrastructure on Yandex Cloud
3. Kubespray to set up Kubernetes on Yandex Cloud

## Steps to build and deploy SWKB App

### Step 1. Prepare credentials
To set up infrastructure on Yandex Cloud you need:
 - Create account on Yandex cloud
 - Get OAuth token, cloud id, folder id, zone (AZ). To get OAuth visit Yandex docs https://cloud.yandex.ru/docs/iam/concepts/authorization/oauth-token
 - Create environment variables:
   - YC_TOKEN=your_oauth_token
   - YC_CLOUD_ID=your_cloud_id
   - YC_FOLDER_ID=your_folder_id
   - YC_ZONE=ru-central1-a ([all Yandex Cloud AZs here](https://cloud.yandex.ru/docs/overview/concepts/geo-scope))
 - Create ssh-key (by default username is ubuntu) and save it to `~\.ssh\id_rsa`. You can change user/key parameters on *variable.tf* file
   - `ssh-keygen -t rsa -b 2048 -C ubuntu@yandex.ru`
 - Create two git-hub secrets (repository secrets) username: DOCKERHUB_USERNAME, DOCKERHUB_TOKEN


### Step 2. Create cloud infrastructure by terraform
Run `terraform apply` from *StarWarsKb.Infrastructure/Terraform* directory. 
If you want to set your db password then run `terraform apply -var="db_password=your_pass"`

By default terraform creates bastion host, 1 master node and 2 worker nodes. You can change these parameters, more info about count and size of nodes is here: *StarWarsKb.Infrastructure/Terraform/README.md*

Output would contain IP of bastion-host.

### Step 3. Create Kubernetes cluster and deploy services

Connect to bastion host by ssh:

`ssh ubuntu@bastion_public_ip`

After that run installation script (I don't know what was wrong with userdata):

`sudo cp /var/lib/cloud/instance/user-data.txt ~/magic.sh && sudo chmod 755 magic.sh && sudo ./magic.sh`

`kubectl`would be installed on master-host.
