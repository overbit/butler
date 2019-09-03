#!/bin/bash
eval $(minikube docker-env)
printf "Building docker images..\n"
docker build -t alfred-api:latest alfred-api/
docker build -t alfred-frontend:latest alfred-frontend/


printf "Apply kubernetes deployment in minikube\n"
kubectl.exe apply -f kubernetes/local/