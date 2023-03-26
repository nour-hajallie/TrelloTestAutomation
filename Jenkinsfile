pipeline {
    agent any
    environment {
        PATH = "${PATH}:C:/Program Files/dotnet"
    }
    stages {
        stage('Checkout code') {
            steps {
                echo 'Hi, GeekFlare. Starting to build the App.'
                checkout scm
                sh "wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh"
                sh "sudo chmod +x ./dotnet-install.sh"
                sh "./dotnet-install.sh --version latest --runtime aspnetcore"
                sh "./dotnet-install.sh --channel 7.0"
            }
        }
        stage('1111') {
            steps {
                sh "cat UnitTest1.cs"
                sh "ls -la"
            }
        }
        stage('Run My Test') {
            steps {
                sh 'dotnet test'
            }
        }
    }
}
