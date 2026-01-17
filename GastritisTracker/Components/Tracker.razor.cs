using Blazored.LocalStorage;
using GastritisTracker.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text; // Needed for [Inject]

namespace GastritisTracker.Components;

public partial class Tracker
{
    // Inject the ILocalStorageService
    [Inject]
    public ILocalStorageService localStorage { get; set; } = default!;

    [Inject]
    public IJSRuntime JS { get; set; } = default!;

    // States
    private LogEntry NewEntry = new LogEntry();

    private List<LogEntry> HistoryLog = new List<LogEntry>();
    private bool IsLoading = true;
    private const string StorageKey = "GastritisTracker_HistoryLog_v1";

    // Lifecycle Methods
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                // Load data from browser LocalStorage
                var data = await localStorage.GetItemAsync<List<LogEntry>>(StorageKey);
                if (data is not null)
                {
                    HistoryLog = data;
                }

                IsLoading = true;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading memory: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
                StateHasChanged();
            }
        }
    }

    // Actions

    private async Task SaveEntry()
    {
        // Add to list
        HistoryLog.Add(new LogEntry
        {
            ItemName = NewEntry.ItemName,
            Feeling = NewEntry.Feeling,
            Date = NewEntry.Date
        });

        // Save to Localstorage
        await localStorage.SetItemAsync(StorageKey, HistoryLog);

        // Rate from inputs (Keep data as today)
        NewEntry = new LogEntry { Date = DateTime.Today };
    }

    private async Task ClearHIstory()
    {
        HistoryLog.Clear();
        await localStorage.RemoveItemAsync(StorageKey);
    }

    // Export  to Excel logic
    private async Task ExportToExcel()
    {
        try
        {
            var builder = new System.Text.StringBuilder();
            builder.AppendLine("Date,Supplement,Feeling");

            foreach (var item in HistoryLog)
            {
                var safeItem = item.ItemName?.Replace(",", " ") ?? "";
                var safeFeeling = item.Feeling?.Replace(",", " ") ?? "";
                builder.AppendLine($"{item.Date:yyyy-MM-dd},{safeItem},{safeFeeling}");
            }

            var fileContent = System.Text.Encoding.UTF8.GetBytes(builder.ToString());

            using var stream = new MemoryStream(fileContent);
            using var streamRef = new DotNetStreamReference(stream);

            var fileName = $"Gastritis_Log_{DateTime.Now:HHmm}.csv";

            // This is where it was likely crashing before
            await JS.InvokeVoidAsync("downloadFileFromStream", fileName, streamRef);
        }
        catch (Exception ex)
        {
            // If something fails, we just log it instead of crashing the app
            Console.WriteLine($"Error exporting: {ex.Message}");
            // Optional: You could show an alert to the user here
            await JS.InvokeVoidAsync("alert", "Error exporting file. Check console.");
        }
    }

    // Delete single  entry
    private async Task DeleteRow(LogEntry logEntry)
    {
        // Remove the specific form the list in memory
        HistoryLog.Remove(logEntry);

        // save the update list to the browser's ,memory (Localstorage)
        await localStorage.SetItemAsync(StorageKey, HistoryLog);

        // Refresh the stats automatically (Blazor does this, but good to know)
    }
}