using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageUIController : MonoBehaviour {

    MessageDialogController messageDialog;
    
    public void StartDialog()
    {
        messageDialog = transform.GetChild(0).GetChild(0).GetComponent<MessageDialogController>();
        messageDialog.Get_Typing();
    }
}
