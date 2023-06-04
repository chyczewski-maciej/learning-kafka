kubectl create namespace confluent
kubectl config set-context --current --namespace confluent

# Install Confluent for Kubernetes.
helm repo add confluentinc https://packages.confluent.io/helm
helm repo update
helm upgrade --install confluent-operator confluentinc/confluent-for-kubernetes

# Install all Confluent Platform components.
kubectl apply -f https://raw.githubusercontent.com/confluentinc/confluent-kubernetes-examples/master/quickstart-deploy/confluent-platform.yaml

# Install sample producer app and topic
kubectl apply -f https://raw.githubusercontent.com/confluentinc/confluent-kubernetes-examples/master/quickstart-deploy/producer-app-data.yaml
kubectl config set-context --current --namespace default