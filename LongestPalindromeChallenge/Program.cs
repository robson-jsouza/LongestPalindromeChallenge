// See https://aka.ms/new-console-template for more information

// In this case, we have two palindromes sub strings: 'samma' and 'kjlabcbaljk'.
// The expected output in this case is: 'kjlabcbaljk'.
string palindromes = "hansammasabcdfgfgkjlabcbaljkhehahihu";
List<string> words = new List<string>();

int length = palindromes.Length;
for (int i = 0; i < length; i++)
{
    if ((length - 1) - i <= 1)
        break;
    string subWord = palindromes.Substring(i, 3);
    words.Add(subWord);

    int initialIndex = i + 3;
    for (int j = initialIndex; j < length; j++)
    {
        subWord += palindromes[j];
        words.Add(subWord);
    }
}

List<string> palindromesFound = new List<string>();
foreach (string subWord in words)
{
    int subWordlength = subWord.Length;
    int halfLength = subWordlength / 2;
    //int halfLength = length / 2;
    bool isPalindrome = true;
    for (int i = 0; i < halfLength; i++)
    {
        if (subWord[i] != subWord[subWordlength - 1 - i])
        {
            isPalindrome = false;
            break;
        }
    }

    if (isPalindrome)
        palindromesFound.Add(subWord);
}

int longestPalindromeLength = 0;
int indexOfLongestPalindrome = -1;
for (int i = 0; i < palindromesFound.Count; i++)
{
    int palindromeFoundLength = palindromesFound[i].Length;
    if (palindromeFoundLength > longestPalindromeLength)
    {
        longestPalindromeLength = palindromeFoundLength;
        indexOfLongestPalindrome = i;
    }
}

if (indexOfLongestPalindrome == -1)
    Console.WriteLine($"Word '{palindromes}' has no palindromes.");
else
    Console.WriteLine($"Longest palindrome found in word '{palindromes}' is: {palindromesFound[indexOfLongestPalindrome]}.");
