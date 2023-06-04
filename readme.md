# 

## Initial requirements (on Windows):

- WSL (wsl --install Ubuntu)
- Podman (podman machine init)
- Minikube (winget install minikube)
- kubectl
- helm
- Telepresence (https://www.telepresence.io/docs/latest/quick-start/)

## Installation/reproduction setps (on Windows)

1. Install all the initial requirements
2. Start minikube and it's addons using `start-minikube.ps1` script
3. Install confluent kafka using `install-confluent-kafka.ps1` script 
4. Install telepresence using `install-telepresence.ps1` script
5. Connect to the cluster using telepresence using `telepresence connect` command
6. Start demo .net project using `dotnet run` in `./dotnet-producer-consumer/KafkaProducer` dir