using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;

public class EditProfile : MonoBehaviour
{
    public InputField m_inputFieldBio;
    public Text m_bioValue;

    // Use this for initialization
    void Start()
    {
        m_inputFieldBio.text = Session.Instance.Cache.Members.TblMembers[0].ColBio;
    }

    public void UpdateProfileUI()
    {
        bool fResult = false;
        fResult = EditProfile._WebUpdateProfile(m_inputFieldBio.text);
        if (true == fResult)
        {
            m_inputFieldBio.text = Session.Instance.Cache.Members.TblMembers[0].ColBio;
            m_bioValue.text = Session.Instance.Cache.Members.TblMembers[0].ColBio;
        }
    }

    private static bool _WebUpdateProfile(string strBio)
    {
        bool fResult = false;
        fResult = Session.Instance.MemberUpdateProfile(
            null,
            null,
            strBio
            );

        return fResult;
    }
}
