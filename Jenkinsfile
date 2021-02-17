pipeline
{
    agent any

    environment
    {
        dotnet = 'c:\\Program Files (x86)\\dotnet\\'
    }

    stages
    {
        stage ('Restore packages')
        {
            steps
            {
                bat "dotnet restore AddressBook.API\\AddressBook.API.csproj"
            }
        }

        stage ('Clean')
        {
            steps
            {
                bat "dotnet clean AddressBook.API\\AddressBook.API.csproj"
            }
        }

        stage ('Build')
        {
            steps
            {
                bat "dotnet build AddressBook.API\\AddressBook.API.csproj --configuration Release"
            }
        }

	stage ('UnitTest')
        {
            steps
            {
                bat "dotnet test AddressBook.API.UnitTests\\AddressBook.API.UnitTests.csproj --no-build --logger:'trx;LogFilePath=output.xml'"
            }
        }

	stage ('Publish')
        {
            steps
            {
                bat "dotnet publish AddressBook.API\\AddressBook.API.csproj"
            }
        }
    }
}