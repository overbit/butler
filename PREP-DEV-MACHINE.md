# Dev machine setup

## Install Chocolatey

If you don't have chocolatey installed then run this in a admin Powershell window:
```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
```

## Install minikube, docker cli and a couple other useful utils

```bash
choco install minikube kubernetes-cli docker-cli kubernetes-helm
```

## Start minikube

```bash
minikube start
```

## Then configure docker cli to use the minikube docker daemon (no need to install docker!)

Run the following every single time you open a new powershell or bash

Powershell admin

```powershell
#This shows you the command:
minikube docker-env
#This is the command but you can add the environment variables shown in the command above to make it perm:
minikube docker-env | Invoke-Expression
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


### To upgrade everything in Choco

```bash
choco upgrade minikube kubernetes-cli docker-cli kubernetes-helm
```

### To enable minikube and/or kubectl autocomplete on Windows

```bash
# Install kubectl / minikube autocomplete
minikube.exe completion bash > ~/minikube-completion.bash
kubectl.exe completion bash > ~/kubectl-completion.bash

# Source in those files in .bashrc like so:
source ~/minikube-completion.bash
source ~/kubectl-completion.bash
alias minikube='minikube.exe'
alias kubectl='kubectl.exe'
```
