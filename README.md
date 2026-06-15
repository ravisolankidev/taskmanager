# Task Manager — C# Console App

A command-line task management application built as part of 
my transition from PHP/Laravel to .NET/C# development.

## What It Demonstrates
- Interface-driven design (ITaskService)
- Dependency injection via constructor
- Repository pattern
- JSON file persistence with System.Text.Json
- LINQ filtering by status
- xUnit integration tests with isolated temp file fixtures
- Async-ready architecture

## Tech Stack
- C# / .NET 10
- xUnit
- System.Text.Json

## Running Locally
git clone https://github.com/ravisolankidev/taskmanager
cd TaskManager
dotnet run

## Running Tests
cd TaskManager.Tests
dotnet test
