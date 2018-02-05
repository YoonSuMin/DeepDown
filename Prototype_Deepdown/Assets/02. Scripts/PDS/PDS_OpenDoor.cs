using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class PDS_OpenDoor : MonoBehaviour {

    public GameObject m_CharacterCamera;

    FirstPersonController m_Character;

    Transform m_OriginPos;
    GameObject m_Puzzle;
    bool m_bIsCheckPuzzle;

	// Use this for initialization
	void Start ()
    {
        Initialize();
    }
	
	// Update is called once per frame
	void Update ()
    {
        CheckPuzzle();
    }

    void Initialize()
    {
        m_Character = GetComponent<FirstPersonController>();
        m_bIsCheckPuzzle = false;
    }

    void CheckPuzzle()
    {
        if (m_CharacterCamera != null)
        {
            if (m_bIsCheckPuzzle == true)
            {
                iTween.MoveTo(m_CharacterCamera, m_Puzzle.transform.localPosition, 5.0f);
                iTween.RotateTo(m_CharacterCamera, Vector3.zero, 5.0f);
            }
        }
    }

    void SetSolvePuzzleCamera(bool value)
    {
        m_Character.enabled = value;
        m_Character.m_MouseLook.SetCursorLock(!value);
        m_bIsCheckPuzzle = value;

        m_Puzzle = GameObject.Find("PuzzlePosition").gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name)
        {
            case "Stage0DoorClose":
                {
                    iTween.RotateTo(gameObject, Vector3.zero, 0.0f);
                    iTween.RotateTo(m_CharacterCamera, Vector3.zero, 1.0f);
                    m_Character.Init();
                }
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.name)
        {
            case "Door":
                {
                    if (CrossPlatformInputManager.GetButton("Jump"))
                    {
                        SetSolvePuzzleCamera(true);
                    }
                }
                break;
        }
    }
}
