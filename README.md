<div align="left" style="position: relative;">
<img src="https://img.icons8.com/external-tal-revivo-regular-tal-revivo/96/external-readme-is-a-easy-to-build-a-developer-hub-that-adapts-to-the-user-logo-regular-tal-revivo.png" align="right" width="30%" style="margin: -20px 0 0 20px;">
<h1DevStack API</h1>
<p align="left">
	<em><code>❯ DevStack API</code></em>
</p>
<p align="left">
	<img src="https://img.shields.io/github/license/dacmarcell/DevStackAPI?style=default&logo=opensourceinitiative&logoColor=white&color=028a02" alt="license">
	<img src="https://img.shields.io/github/last-commit/dacmarcell/DevStackAPI?style=default&logo=git&logoColor=white&color=028a02" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/dacmarcell/DevStackAPI?style=default&color=028a02" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/dacmarcell/DevStackAPI?style=default&color=028a02" alt="repo-language-count">
</p>
<p align="left"><!-- default option, no dependency badges. -->
</p>
<p align="left">
	<!-- default option, no dependency badges. -->
</p>
</div>
<br clear="right">

## 🔗 Table of Contents

- [📍 Overview](#-overview)
- [👾 Features](#-features)
- [🚀 Getting Started](#-getting-started)
  - [☑️ Prerequisites](#-prerequisites)
  - [⚙️ Installation](#-installation)
  - [🤖 Usage](#🤖-usage)
  - [🧪 Testing](#🧪-testing)
- [📌 Project Roadmap](#-project-roadmap)
- [🔰 Contributing](#-contributing)
- [🎗 License](#-license)
- [🙌 Acknowledgments](#-acknowledgments)

---

## 📍 Overview

Showcase your profile with simplicity and professionalism using our API!

Whether you're a beginner programmer looking to explore API consumption or someone aiming to create a centralized and functional portfolio, our API is the perfect choice.

With it, you can:
✅ Add and remove social media links, posts, and projects to your profile;
✅ Organize your portfolio efficiently and with a personal touch;
✅ Learn how to consume APIs while building something real for your professional growth.

Perfect for beginners!
Easily implement it into your applications and start experiencing the power of APIs in the development world.

---

## 👾 Features

<code>❯Create a profile</code>
<code>❯Add or remove a post to profile</code>
<code>❯Add or remove a project to profile</code>
<code>❯Add or remove a social media to profile</code>

---

## 📁 Project Structure

```sh
└── DevStackAPI/
    ├── Controllers
    │   ├── PostController.cs
    │   ├── ProfileController.cs
    │   ├── ProjectController.cs
    │   └── SocialMediaController.cs
    ├── Database
    │   └── ApplicationDBContext.cs
    ├── Dtos
    │   ├── PostDtos
    │   ├── ProfileDtos
    │   ├── ProjectDtos
    │   └── SocialMediaDtos
    ├── Enums
    │   ├── ConnectOrDisconnect.cs
    │   └── SocialMediaNames.cs
    ├── Migrations
    │   ├── ...
    ├── Models
    │   ├── Post.cs
    │   ├── Profile.cs
    │   ├── Project.cs
    │   └── SocialMedia.cs
    ├── Program.cs
    ├── Properties
    │   └── launchSettings.json
    ├── appsettings.Development.json
    ├── appsettings.json
    ├── compose.yml
    ├── portfolio-api.csproj
    ├── portfolio-api.http
    ├── portfolio-api.sln
    └── start-dev.sh
```

---
## 🚀 Getting Started

### ☑️ Prerequisites

Before getting started with portfolio-api, ensure your runtime environment meets the following requirements:

- **Programming Language:** CSharp
- **Package Manager:** Nuget


### ⚙️ Installation

Install portfolio-api using one of the following methods:

**Build from source:**

1. Clone the portfolio-api repository:
```sh
❯ git clone https://github.com/dacmarcell/DevStackAPI
```

2. Navigate to the project directory:
```sh
❯ cd DevStackAPI
```

3. Install the project dependencies:


**Using `nuget`** &nbsp; [<img align="center" src="https://img.shields.io/badge/C%23-239120.svg?style={badge_style}&logo=c-sharp&logoColor=white" />](https://docs.microsoft.com/en-us/dotnet/csharp/)

```sh
❯ dotnet restore
```




### 🤖 Usage
Run portfolio-api using the following command:
**Using `nuget`** &nbsp; [<img align="center" src="https://img.shields.io/badge/C%23-239120.svg?style={badge_style}&logo=c-sharp&logoColor=white" />](https://docs.microsoft.com/en-us/dotnet/csharp/)

```sh
❯ dotnet run
```


### 🧪 Testing
Run the test suite using the following command:
**Using `nuget`** &nbsp; [<img align="center" src="https://img.shields.io/badge/C%23-239120.svg?style={badge_style}&logo=c-sharp&logoColor=white" />](https://docs.microsoft.com/en-us/dotnet/csharp/)

```sh
❯ dotnet test
```


---
## 📌 Project Roadmap

- [X] **`Task 1`**: <strike>Finish business rule.</strike>
- [ ] **`Task 2`**: Prettify Code.
- [ ] **`Task 3`**: Implement Cache.
- [ ] **`Task 4`**: Deploy to Azure.

---

## 🔰 Contributing

- **💬 [Join the Discussions](https://github.com/dacmarcell/DevStackAPI/discussions)**: Share your insights, provide feedback, or ask questions.
- **🐛 [Report Issues](https://github.com/dacmarcell/DevStackAPI/issues)**: Submit bugs found or log feature requests for the `portfolio-api` project.
- **💡 [Submit Pull Requests](https://github.com/dacmarcell/DevStackAPI/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/dacmarcell/DevStackAPI
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/dacmarcell/DevStackAPI/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=dacmarcell/portfolio-api">
   </a>
</p>
</details>

---

## 🎗 License

This project is protected under the [SELECT-A-LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

## 🙌 Acknowledgments

- List any resources, contributors, inspiration, etc. here.

---
