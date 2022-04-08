pipeline {
    agent any

    tools {nodejs "NodeJS"}

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
        stage('Building: API') {
        /* when {
            anyOf {
                changeset "BackendAPI/**"
            }
        } */
            steps{
                sh "echo '[API] Building...'"
                sh "dotnet build BackendAPI/WebApplication.sln"
                sh "docker-compose build api"
            }
            post {
            		success {
            		    sh "echo 'API built successfully'"
            		}
            	}
        }
	
	stage('Back-end tests') {
	        when {
                    anyOf {
                        changeset "BackendAPI/**"
                    }
                }
    		steps{
    		    dir ("BackendAPI/Core.Test/BackendTests") {
    		        sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
    		    }
    		}
    		post {
                success {
                    archiveArtifacts "BackendAPI/Core.Test/BackendTests/TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [coberturaAdapter(path: 'BackendAPI/Core.Test/BackendTests/*/coverage.cobertura.xml', thresholds: [[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE')
                }
            }
    	}
    	
        stage('Building: Frontend') {
                when {
                    anyOf {
                        changeset "FrontendHappy/**"
                    }
                }
            steps{
                sh "echo '[FRONTEND] Building...'" 
                dir("FrontendHappy"){
                    sh "npm install"
                    sh "ng build"
                }
            }
        }
        
        stage("Reset containers"){
            steps{
                script{
                    try{
                        sh "docker-compose down"
                    }
                    finally {}
                }
            }
        }
        
        stage("Deploy"){
            steps{
                sh "docker-compose up -d"
            }
        }
    }
    post {
        always {
            withCredentials([string(credentialsId: 'DISCORD_WEB_HOOK', variable: 'WEB_HOOK')]) {
                discordSend description: 'The pipeline from Drunken snakes was run', footer: '', image: '', link: '', result: '', scmWebUrl: '', thumbnail: 'https://cdn.discordapp.com/attachments/938788614006014007/954364061661954118/unnamed.jpg', title: 'Drunken Snake', webhookURL: WEB_HOOK
            }
        }
    }
}