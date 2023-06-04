podman machine init --rootful
podman machine start

minikube delete
minikube config set driver podman
minikube config set container-runtime cri-o
minikube config set rootless false
minikube config set memory 16384
minikube config set cpus 8

minikube start
minikube update-context

minikube addons enable metrics-server
minikube addons enable metallb
minikube addons enable csi-hostpath-driver
# minikube addons enable ingress