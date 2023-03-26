pipeline {
  agent any
  stages {
    stage('Checkout') {
      steps {
        git 'https://github.com/nour-hajallie/TrelloTestAutomation.git'
      }
    }
    stage('Build') {
      steps {
        bat 'msbuild /target:library /out:TrelloUnitTest.dll /reference:System.Net.Http.dll UnitTest1.cs'
      }
    }
    stage('Test') {
      steps {
        bat 'vstest.console.exe TrelloUnitTest.dll'
      }
    }
  }
}


