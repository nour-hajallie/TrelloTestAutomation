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
        stage('1111') {
            steps {
                sh "cat UnitTest1.cs"
                sh "ls -la"
            }
        }
        stage('Build') {
    steps {
        bat "msbuild TrelloTestAutomation.csproj /t:Build /p:Configuration=Release"
    }
}
stage('Test') {
      steps {
        bat 'vstest.console.exe TrelloTestAutomation.dll'
      }
    }
        stage('Run My Test') {
            steps {
                sh 'dotnet test'
            }
        }
    }
}
