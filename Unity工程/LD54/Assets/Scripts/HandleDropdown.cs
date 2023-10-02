using UnityEngine;
using UnityEngine.UI;

public class HandleDropdown : MonoBehaviour
{
    private Dropdown _dropdown;
    
    // Start is called before the first frame update
    private void Start()
    {
        _dropdown = GetComponent<Dropdown>();
        _dropdown.value = PlayerPrefs.GetInt("language", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLanguage()
    {
        Debug.Log(_dropdown.value.ToString());
        GameManager.instance.language = _dropdown.value;
        PlayerPrefs.SetInt("language", _dropdown.value);
    }
    
}
