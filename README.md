# 🩺 Gastritis Tracker

A modern, interactive health journal built with **Blazor Web App (.NET 10)**.

This application was designed to solve a real-world problem: tracking the correlation between specific supplements (like Manuka Honey, Collagen, Omega 3) and stomach symptoms (Gastritis/Esophagitis) to identify triggers and improve recovery.

<img width="2005" height="235" alt="image" src="https://github.com/user-attachments/assets/09fa87a9-0669-43d8-b02e-78ee940cf7d1" />


## ✨ Key Features

* **📝 Daily Symptom Logging:** Record supplements taken and the resulting physical sensation.
* **📊 Real-time Dashboard:** Visual statistics showing "Good Days" vs. "Flare-ups" and identifying the most consumed items.
* **💾 Local Persistence:** Uses `Blazored.LocalStorage` to save data directly in the browser—no database setup required.
* **📉 Smart Analysis:** Automatically highlights "burning" or "pain" symptoms in red and positive outcomes in green.
* **📑 Medical Export:** One-click export to **CSV (Excel)** to share logs with gastroenterologists.
* **🛡️ Safety Filters:** Includes logic to filter or warn about specific supplements (e.g., Aloe Vera safety checks).

## 🛠️ Tech Stack

* **Framework:** .NET 10 (Blazor Web App)
* **Render Mode:** Interactive Server
* **Language:** C#
* **Libraries:**
    * `Blazored.LocalStorage` (for persistence)
    * `Bootstrap 5` (for UI/UX)
* **Concepts Applied:** LINQ, Dependency Injection, Async/Await, Javascript Interop.

## 🚀 How to Run

1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/your-username/GastritisTracker.git](https://github.com/your-username/GastritisTracker.git)
    ```

2.  **Navigate to the project folder:**
    ```bash
    cd GastritisTracker
    ```

3.  **Run the application:**
    ```bash
    dotnet watch
    ```

4.  Open your browser at `https://localhost:7198` (or the port shown in your terminal).

## 📸 Screenshots

### The Tracker Interface
<img width="2548" height="1348" alt="image" src="https://github.com/user-attachments/assets/c3e546c8-3413-4e18-b0cc-943fc3ae253c" />


### Export Feature
Generates a clean CSV file for medical review:
<img width="2501" height="1085" alt="image" src="https://github.com/user-attachments/assets/1b3c2fe2-be67-4c2c-9c45-2e947df1d160" />


## 👤 Author

**Emilio Antonio Barrera Sepulveda** Learning and building with Blazor.

---
*This project is for educational and personal tracking purposes.*
