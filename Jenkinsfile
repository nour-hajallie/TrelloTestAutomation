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
            }
        }
        stage('Run My Test') {
            steps {
                sh 'dotnet test'
            }
        }
    }
}
