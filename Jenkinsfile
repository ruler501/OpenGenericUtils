PROJECTS = ["OpenGenericsUtils/OpenGenericsUtils"]
TEST_PROJECTS = ["OpenGenericsUtils/Tests/OpenGenericsUtils.Tests"]

def command_in_each(list, cmd) {
    for (int i = 0; i < list.size(); i++) {
        dir(list[i]) {
			sh cmd
		}
    }
}

pipeline {

	agent any

	options {
		timestamps()
	}
	
	stages {
		stage('Build') {
			steps {
				command_in_each(PROJECTS, "dotnet build")
			}
		}
		
		stage('Test') {
			steps {
				command_in_each(TEST_PROJECTS, "dotnet test")
			}
		}
	}
	
	triggers {
        githubBranches events: [commit([])], spec: '', triggerMode: 'HEAVY_HOOKS'
        githubPullRequests events: [Open(), commitChanged()], spec: '', triggerMode: 'HEAVY_HOOKS'
    }
}