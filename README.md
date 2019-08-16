# Alfred api and frontend

To run alfred locally you can use Kestrel and nodejs or Kubernetes (minikube)

## Run in Kestrel and nodejs

```bash
./run-KestrelNode.sh
```

## Run in containers with Kubernetes (minikube)

### Prep work

#### Install Chocolatey

Install with cmd.exe
Run the following command:   (copy command text)

```cmd
@"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -InputFormat None -ExecutionPolicy Bypass -Command "iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))" && SET "PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin"
```

Install with PowerShell.exe
With PowerShell, there is an additional step. You must ensure Get-ExecutionPolicy is not Restricted. We suggest using Bypass to bypass the policy to get things installed or AllSigned for quite a bit more security.

- Run Get-ExecutionPolicy. If it returns Restricted, then run Set-ExecutionPolicy AllSigned or Set-ExecutionPolicy Bypass -Scope Process.
- Now run the following command:   (copy command text)

```powershell
Set-ExecutionPolicy Bypass -Scope Process -Force; iex ((New-Object System.Net.WebClient).DownloadString('https://chocolatey.org/install.ps1'))
```

#### Install minikube

```bash
choco install minikube
```

### Use docker images in minikube

```bash
# Set the environment variables to being able to store docker images in minikube
eval $(minikube docker-env)

# Build the image with the Docker daemon of Minikube (eg docker build -t my-image .)
docker build -t alfred-api:latest alfred-api/
docker build -t alfred-frontend:latest alfred-frontend/

# Check docker images created
docker images -a
```

### Start minikube

```bash
minikube start
```

### Enable the Ingress controller in minikube

```bash
# To enable the NGINX Ingress controller
minikube addons enable ingress

# Verify that the NGINX Ingress controller is running
kubectl get pods -n kube-system
```

### Apply k8s deployment and services

From the parent directory of the alfred repo and apply the local kubernetes configs.
This will generate 2 services (alfred-api and alfred-frontend) and setup an ingress controller

```bash
kubectl apply -f kubernetes/local/
```

### Get the status of the deployment

```bash
kubectl get all
```

### Add the new ingress host to your hostfile

```bash
# Get the minikube cluster ip
minikube ip
```

Add it (i.e. 192.168.99.102) to the end of your host file like:

```text
# Minikube
192.168.99.102 dev.alfred
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
