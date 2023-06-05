# My personal Kafka materials

## Current state of the affairs

Steps below document how a simple minikube kafka environment can be setup. This if not a production grade solution, of course.

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
3. Install confluent kafka using `install-confluent-kafka.ps1` script. This is mostly based on the [Confluent for Kubernetes Quickstart](https://docs.confluent.io/operator/current/co-quickstart.html#co-quickstart)
4. Install telepresence in the cluster using `install-telepresence.ps1` script
5. Connect to the cluster using telepresence using `telepresence connect` command
6. Go to `http://controlcenter.confluent:9021/clusters` and create topic named `sample-topic`
7. Start demo .net producer using `dotnet run` in `./dotnet-producer-consumer/KafkaProducer` dir
8. Start demo .net consumer using `dotnet run` in `./dotnet-producer-consumer/KafkaConsumer` dir