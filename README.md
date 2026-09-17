# Playwright NUnit E2E Test Automation

This repository contains an end-to-end (E2E) UI test automation framework built with **Microsoft Playwright**, **C#**, and **NUnit**. It follows the Page Object Model (POM) design pattern and utilizes **Allure** for comprehensive test reporting.

## 🚀 Tech Stack

- **Language:** C# (.NET 9.0)
- **Testing Framework:** NUnit 4
- **Automation Tool:** Playwright for .NET
- **Reporting:** Allure
- **Test Data Generation:** Bogus
- **CI/CD:** GitHub Actions

## 📁 Project Structure

- `Pages/` - Page Object Model classes representing UI pages (e.g., `LoginPage`, `InventoryPage`, `CartPage`).
- `Tests/` - Test classes containing the E2E test scenarios.
- `TestData/` - Constants and dynamic test data generation (using Bogus).
- `Helpers/` - Utility and helper classes for shared logic (e.g., `AuthorizationHelper`).
- `Extensions/` - Custom extension methods.
- `allureConfig.json` - Configuration for Allure reporting.

## 🛠️ Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or later.
- IDE of your choice (Visual Studio, VS Code, or JetBrains Rider).
- [Allure Commandline](https://allurereport.org/docs/install/) (for viewing reports locally).

## ⚙️ Setup & Installation

1. **Clone the repository:**
   ```bash
   git clone <your-repo-url>
   cd myNUnit
   ```

2. **Build the project and install dependencies:**
   ```bash
   dotnet build
   ```

3. **Install Playwright Browsers:**
   Playwright requires specific browser binaries to run tests. After building, run the following PowerShell script from your output directory:
   ```bash
   pwsh bin/Debug/net9.0/playwright.ps1 install
   ```

## ▶️ Running Tests

To execute all tests, use the standard .NET CLI command:
```bash
dotnet test
```
*Note: Depending on your `playwright.runsettings` file, you can customize browser types, headless/headed mode, and other configurations.*

## 📊 Test Reporting (Allure)

This project uses Allure for detailed and visual test reports. After running your tests, the raw results are generated in the `bin/Debug/net9.0/allure-results/` directory.

To generate and serve the report locally, run:
```bash
allure serve bin/Debug/net9.0/allure-results
```

## 🔄 CI/CD Pipeline

This project is integrated with **GitHub Actions**. The pipeline defined in `.github/workflows/playwright.yml` automatically triggers on commits or pull requests, setting up .NET, installing Playwright browsers, executing the test suite, and handling the artifacts.
