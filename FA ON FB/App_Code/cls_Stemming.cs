using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using WordNetClasses;
//using WordsMatching;
using System.Text;
using System.Collections;
/// <summary>
/// Summary description for cls_Stemming
/// </summary>
public class cls_Stemming
{
	public cls_Stemming()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    String[] WS = { '"' + "", "!", "♥", " ", "@", "#", "$", "%", "^", "&", "*", "(", ")", "\r", "\n", "_", ",", "+", "=", "~", "'", "`", "{", "[", "]", "}", ":", ";", "’", ",", "<", ">", ".", "?", "/", "\\", "|", "—", "-", "–", "“", "”", "®", "0", "9", "8", "7", "6", "5", "4", "3", "2", "1", "•", "‘", "″", "©", "·" };

    string[] twofrm = new String[] { "'s", "ed", "es", "al", "er", "or", "ee", "ly", "ar", "or", "ly" };
    string[] threefrm = new String[] { "ful", "ive", "ial", "ous", "ism", "ess", "ian", "ics", "ist","ing" };
    string[] fourfrm = new String[] { "ment", "tion", "ious", "ness", "ance", "ence", "ness", "ship", "ally" };
    string[] fivefrm = new String[] { "ation" };
    string[] sixfrm = new string[] { "graphy" };

    String[] Cntrs = {"\r\n","\r","\n","your","get","others","you","find","only","for","s", "a","all","out","is","was","am","my","why","of","hai","from","to","do","in","at","by","it","its","has","which","to","be",
                     "an","should","such","on","our","etc","up","more",
                     "the","we","are","they","must","th",
                     "what","with","most","each","this","every",
                     "other","many","unless","although","because","same","thing","here","about",
                     "and","but","either",
                     "nor","even","though","how","can",
                     "but","however","neither",
                     "or","otherwise","since", 
                     "yet","unless","actually",
                     "so","it's","basically",
                     "after","so","well","following",
                     "if","ok","before","while",
                     "though","once","first","soon","later","ever","next","then","there","may","cause","their","still","due","been","into","who","without","any","another","using","said","hence","own","will","between","involved","relate","these","fact","firstly","thereafter",
                     "although","second","secondly","third","thirdly","finally","last","lastly",
                     "either","whereas","though","instead","however","on","also",
                     "unless","further","moreover",
                     "as long as","in","case","unless","not",
                     "rather than",
                     "where",
                     "even if",
                     "that",
                     "as if",
                     "once",
                     "whenever",
                     "before",
                     "than",
                     "now that",
                     "when",
                     "because",
                     "so that",
                     "wherever",
                     "while",
                     "until",
                     "as though",
                     "since",
                     "whereas",
                     "even though",
                     "accordingly",
                     "indeed",
                     "similarly",
                     "conversely",
                     "moreover",
                     "therefore",
                     "both",
                     "not only",
                     "but also",
                     "not",
                     "but",
                     "either",
                     "neither",
                     "whether",
                     "as",
                     "similarily",
                     "likewise",
                     "also",
                     "however",
                     "on the other hand","us"
                     };

    public string[] StpRmv(String cnt)
    {
        string[] SplitItem = cnt.Split(WS, StringSplitOptions.RemoveEmptyEntries);
        return SplitItem;
    }
    public string stoprmv(String cnt)
    {
        string[] SplitItem = cnt.Split(WS, StringSplitOptions.RemoveEmptyEntries);
        string cmd = "";
        foreach (string str in SplitItem)
        {
            cmd += str + " ";

        }
        return cmd;
    }

    public string Arr2Strng(string[] str)
    {
        string newstr = "";

        for (int i = 0; i < str.Length; i++)
        {
            newstr = newstr + str[i] + " ";
        }
        return newstr;
    }
    public bool cntrs(string str)
    {
        if (Cntrs.Contains(str.ToLower()) == true)
        {
            return true;
        }

        return false;

    }

    public string rwvnullspace(string ssn)
    {

        string[] s = ssn.Split(' ');
        string newstr = "";
        for (int j = 0; j < s.Length; j++)
        {

            if (s[j] == "")
            {
            }
            else
            {
                newstr = newstr + s[j] + " ";
            }
        }
        return newstr;

    }


    public string[] Rmvfrm(string str)
    {
        //str = removechars(str);
        string[] st = str.Split(' ');

        for (int i = 0; i < st.Length; i++)
        {


            if (st[i].Length >= 5)
            {

                try
                {
                    if (fivefrm.Contains((st[i].Substring(st[i].Length - 5))) == true)
                    {
                        if (st[i].Length > 9)
                        {
                            st[i] = st[i].Substring(0, st[i].Length - 5);
                            goto l1;
                        }
                    }
                }
                catch { }


                try
                {
                    if (fourfrm.Contains((st[i].Substring(st[i].Length - 4))) == true)
                    {
                        if (st[i].Length > 8)
                        {
                            st[i] = st[i].Substring(0, st[i].Length - 4);
                            goto l1;
                        }
                    }
                }
                catch { }



                try
                {
                    if (threefrm.Contains((st[i].Substring(st[i].Length - 3))) == true)
                    {
                        if (st[i].Length >= 5)
                        {
                            st[i] = st[i].Substring(0, st[i].Length - 3);
                            goto l1;
                        }
                    }
                }
                catch { }


                try
                {
                    if (twofrm.Contains((st[i].Substring(st[i].Length - 2))) == true)
                    {
                        if (st[i].Length > 4)
                        {
                            st[i] = st[i].Substring(0, st[i].Length - 2);
                            goto l1;
                        }
                    }
                }
                catch { }


            l1: int y = 0;
            }
        }

        return st;
    }
    //  char[] c = { 'a', 'e', 'i', 'o', 'u' };
    ArrayList chars = new ArrayList();
    ArrayList indices = new ArrayList();
    string removechars(string st)
    {
        int len = st.Length;
        string s = "";
        int cnt = 0;
        for (int i = 0; i < -1; i++)
        {
            if (s[i] == s[i - 1])
            {
                cnt++;
            }
            else
                cnt = 0;
            if (cnt != 2)
            {
                s += st[i];
            }
        }
        return st;

    }


    //public List<string> mywordnet(List<string> words)
    //{
    //    //Wnlib.WNCommon.path = @"C:\Program Files (x86)\WordNet\2.1\dict";
    //    //SentenceSimilarity sm = new SentenceSimilarity();
    //    // StringBuilder sb = new StringBuilder();
    //    for (int i = 0; i < words.Count - 1; i++)
    //    {
    //        string w1 = words[i];
    //        for (int j = i + 1; j < words.Count; j++)
    //        {
    //            try
    //            {
    //                string w2 = words[j];
    //                if (sm.GetScore(w1, w2) > .75f)
    //                {
    //                    if (w1.Length > w2.Length)
    //                    {
    //                        words.RemoveAt(i);
    //                        i--;
    //                        break;
    //                    }
    //                    else
    //                    {
    //                        words.RemoveAt(j);
    //                        j--;

    //                    }
    //                }
    //            }
    //            catch
    //            {

    //            }
    //        }

    //    }
    //    return words;
    //}


    public static bool similarwords(string s1, string s2)
    {
        return s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase);

    }


}