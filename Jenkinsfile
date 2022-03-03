pipeline {
    agent any
    triggers {
        pollSCM "*/5 * * * *"
    }
    stages {
        stage('Build Api') {
            steps{
                sh "echo '[API] Building...'"
                dotnet build BackendAPI/WebApplication.sln
            }
        }
        stage('Build Frontend') {
            steps{
                sh "echo '[FRONTEND] Building...'" 
            }
        }
    }
}