# Alfred api and frontend

## Run in Kestrel and nodejs 

```bash
./startLocal.sh
```

## Run in containers with kubernetes (minikube) 

### Move to the kubernetes directory of the alfred repo and apply the local kubernetes config

```bash
kubectl apply -f local-alfred.yaml
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
```
