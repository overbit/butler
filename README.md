# Alfred api and frontend

## Run in Kestrel and nodejs 

```bash
./startLocal.sh
```

## Run in containers with kubernetes (minikube) 

### Use docker images in minikube

Set the environment variables with 

```bash
eval $(minikube docker-env)
```

Build the image with the Docker daemon of Minikube (eg docker build -t my-image .)
```bash
docker build -t alfred-api:latest alfred-api/
docker build -t alfred-frontend:latest alfred-frontend/
```

Check docker images created
```bash
docker images -a
```

Set the image in the pod spec like the build tag (eg my-image)
Set the imagePullPolicy to Never, otherwise Kubernetes will try to download the image.

### Start minikube

```bash
minikube start
```

### Move to the kubernetes directory of the alfred repo and apply the local kubernetes config

```bash
kubectl apply -f kubernetes/local-alfred.yaml
```

### Get the status of the deployment

```bash
kubectl get all
```

### For more info

```bash
kubectl get all -o wide
kubectl get all --all-namespaces
#These commands don't actually get all resources. To see a list of resource types:
kubectl api-resources
#Use the describe command for detailed info on a resource:
kubectl describe deployment/alfred
# These command To expose the service and open a web page:
minikube service alfred

# Start Kubernetes dashboard
minikube dashboard
```


