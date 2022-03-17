pipeline {
    agent any

    tools {nodejs "NodeJS"}

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
        stage('Building: API') {
            steps{
                sh "echo '[API] Building...'"
                sh "dotnet build BackendAPI/WebApplication.sln"
            }
            post {
            		success {
            		sh "echo 'API built successfully'"
            		}
            	}
        }
	
	stage('Back-end tests') {
    		steps{
    		    dir ("BackendAPI/Core.Test/BackendTests") {
    		        sh "dotnet test"
    		    }
    		}
    	}
    	
        stage('Building: Frontend') {
            steps{
                sh "echo '[FRONTEND] Building...'" 
                dir("FrontendHappy"){
                    sh "npm install"
                    sh "ng build"
                }
            }
        }
        
        stage('Deliver: Frontend') {
            steps{
                sh "docker stop front-end"
                sh "docker rm -f front-end"
                sh "docker build -f dockerfile -t frontend-docker-image ."
                sh "docker run --name front-end -d -p 8081:80 frontend-docker-image"
            }
        }

        stage('Deliver: Backend'){
            steps{
                dir("BackendAPI"){
                    sh "docker stop back-end"
                    sh "docker rm -f back-end"
                    sh "docker build -f dockerfile -t backend-docker-image ."
                    sh "docker run --name back-end -d -p 8082:81 backend-docker-image"
                }
            }
        }
    }
}