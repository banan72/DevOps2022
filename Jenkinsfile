pipeline {
    agent any

    tools {nodejs "NodeJS"}

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
        stage('Build Api') {
            steps{
                sh "echo '[API] Building...'"
                sh "dotnet build BackendAPI/WebApplication.sln"
            }
        }
        stage('Build Frontend') {
            steps{
                sh "echo '[FRONTEND] Building...'" 
                dir("FrontendHappy"){
                    sh "npm install"
                    sh "ng build"
                }
            }
        }
    }
}