pipeline {
    agent any
    stages {
        stage('Checkout code') {
            steps {
                echo 'Starting to build the App.'
                checkout scm
            }
        }
        stage('Run My Test') {
            steps {
                    echo 'Rum My Test'
                    sh 'pwd'
                    sh 'dotnet test'
            }
        }
        stage('Retrieve logs') {
            steps {
                    sh 'cat /var/lib/jenkins/workspace/trello/bin/Debug/net6.0/Logs/LogReport.log'
                    sh 'cp /var/lib/jenkins/workspace/trello/bin/Debug/net6.0/Logs/LogReport.log ./'
                    archiveArtifacts artifacts: 'LogReport.log', onlyIfSuccessful: false
                    }
            }
}
