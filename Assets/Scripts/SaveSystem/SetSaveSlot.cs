using UnityEngine;

public class SetSaveSlot : MonoBehaviour
{
    public void SetSaveSlotTo(int slot)
    {
        SaveAndLoadSystem.saveSlot = slot;
        //Debug.Log(SaveAndLoadSystem.saveSlot);
    }
}