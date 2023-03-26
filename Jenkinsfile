pipeline {
  agent any

  environment {
    // Set the GitHub PAT as an environment variable
    GITHUB_TOKEN = credentials('github-token')
  }

  stages {
    stage('Clone Repository') {
      steps {
        // Clone the GitHub repository using HTTPS URL and the GITHUB_TOKEN environment variable
        git credentialsId: 'github-token', url: 'https://github.com/nour-hajallie/TrelloTestAutomation.git'
      }
    }

    // Other stages in your pipeline
  }
}