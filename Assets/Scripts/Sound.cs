using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    #region Properties
    public string Name => _name;
    public AudioClip Clip => _clip;
    public AudioMixerGroup Output => _output;
    public bool Loop => _loop;
    public float Volume => _volume;
    public float Pitch => _pitch;
    public AudioSource Source
    {
        get { return _source; }
        set { _source = value; }
    }
    #endregion

    [SerializeField] private string _name = "New Sound";
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioMixerGroup _output;
    [SerializeField] private bool _loop;
    [SerializeField][Range(0f, 1f)] private float _volume = 1;
    [SerializeField][Range(-3, 3f)] private float _pitch = 1;
    private AudioSource _source;
}
