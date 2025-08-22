## Demo: Software Testing (C#)

- Purpose: Group demo for a university Software Testing course.
- Unit tests: read Excel (.xlsx) with EPPlus and TXT files with C# I/O.
- UI tests: Selenium WebDriver for basic GitHub flows.

Quick start:
- Open solution: `KTPM_53_Hao/WindowsFormsApp1/WFA_53_Hao.sln`
- Restore NuGet, Build the solution
- Run tests in Test Explorer:
  - Unit: `HinhTronTest_53_Hao`, `PhuongThucChung_53_Hao` (data in `HinhTronTest_53_Hao/Data_53_Hao` and `.txt` files)
  - UI: `GithubTest_53_Hao` (requires Chrome + matching ChromeDriver)

Dependencies: MSTest, EPPlus, Selenium WebDriver, ChromeDriver.