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
                    script {
                    def date = new Date().format("yyyyMMdd")
                    sh "cat /var/lib/jenkins/workspace/trello/bin/Debug/net6.0/Logs/LogReport.logLogs/LogReport_${date}.log"
                    sh "cp /var/lib/jenkins/workspace/trello/bin/Debug/net6.0/Logs/LogReport.logLogs/LogReport_${date}.log ./"
                    archiveArtifacts artifacts: "LogReport_${date}.log", onlyIfSuccessful: false
                }
            }
        }
            }
}