﻿using RemoteDataModule.SharedMessages;
using RemoteDataModule.SharedMessages.MessageData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageControls : MonoBehaviour
{
    private SharedMessagesService _service;
    private FirebaseAuthModule _authModule;

    [SerializeField]
    private InputField _userIdField;
    [SerializeField]
    private InputField _messageField;

    public void Init(SharedMessagesService service, FirebaseAuthModule authModule)
    {
        this._service = service;
        this._authModule = authModule;
    }

    public void FetchAndProceed()
    {
        _service.Run();
    }

    public void PushTextMessage()
    {
        var userId = _userIdField.text;
        var message = _messageField.text;
        var sharedMessage = new TextSharedMessage()
        {
            MessageOwner = _authModule.CurrentUserId,
            MessageText = message
        };
        _service.PushMessage(userId, sharedMessage);
    }

}
