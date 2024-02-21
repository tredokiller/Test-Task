using System;
using Controllers;
using Managers;
using Models;
using Repository;
using Services;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public ButtonsController ButtonsController { private set; get; }
    private IRepository<ButtonModel> _buttonsRepository;

    private ButtonsService _buttonsService;

    private ButtonsManager _buttonsManager;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        _buttonsManager = ButtonsManager.instance;
        
        _buttonsRepository = new ButtonsRepository(_buttonsManager);
        _buttonsService = new ButtonsService(_buttonsRepository);
        ButtonsController = new ButtonsController(_buttonsService);
    }

    private void Start()
    {
        Init();
    }
}
