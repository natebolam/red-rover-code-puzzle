# Red Rover Code Puzzle

This project is an ASP.NET Core Web API application built to covert:

`"(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)"`

To this output:

```text
- id
- name
- email
- type
  - id
  - name
  - customFields
    - c1
    - c2
    - c3
- externalId
```

And also to this output:

```text
- email
- externalId
- id
- name
- type
  - customFields
    - c1
    - c2
    - c3
  - id
  - name
```

## Features

- **ASP.NET Core**: Built using the latest ASP.NET Core framework.
- **Swagger UI**: Integrated Swagger UI for testing and exploring the API.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)
- Azure account for deployment (optional)

### Setup and Run Locally

- Clone the Repository

```bash
git clone https://github.com/natebolam/red-rover-code-puzzle.git
cd red-rover-code-puzzle
```

- Run the API locally

```bash
dotnet run --launch-profile https
```
