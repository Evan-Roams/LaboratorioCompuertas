using System.Threading.Tasks;
using UnityEngine;

public class ForDoorButton : MonoBehaviour
{
    public Button openButton;
    public Button closeButton;

    public DoorController door;

    public bool testOpen;
    public bool testClose;

    public bool busy;

    async void Update()
    {
        if (busy)
            return;

        if (testOpen)
        {
            testOpen = false;

            await OpenDoor();
        }

        if (testClose)
        {
            testClose = false;

            await CloseDoor();
        }
    }

    public async Task<bool> OpenDoor()
    {
        if (busy)
            return false;

        if (!openButton.PressButton())
            return false;

        busy = true;

        door.Open();

        // Esperar hasta que abra completamente
        while (!door.isOpened)
        {
            await Task.Yield();
        }

        busy = false;

        return true;
    }

    public async Task<bool> CloseDoor()
    {
        if (busy)
            return false;

        if (door.isClosed)
            return false;

        busy = true;

        door.Close();

        // Esperar hasta que cierre completamente
        while (!door.isClosed)
        {
            await Task.Yield();
        }

        busy = false;

        return true;
    }
}