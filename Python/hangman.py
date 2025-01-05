import time
from random import randint
import os
import copy

HANGMANPICS = ['''
  +---+
  |   |
      |
      |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
      |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
  |   |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========''', '''
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
=========''']

categories=['Animals', 'Countries', 'Food', 'Sports']
words=[['LION','ELEPHANT','TIGER','GIRAFFE','DOLPHIN','PENGUIN','KOALA','KANGAROO','ZEBRA','CHEETAH','GORILLA','HIPPOPTAMUS', 'CROCODILE', 'CHIMPANZEE', 'LIZARD']
,['CANADA', 'JAPAN', 'BRAZIL', 'AUSTRIA', 'FRANCE', 'MEXICO', 'GERMANY', 'PAKISTAN', 'ITALY', 'CHINA', 'RUSSIA', 'SPAIN', 'EGYPT', 'CROATIA', 'SERBIA']
,['PIZZA', 'SUSHI','BURGER', 'PANCAKE', 'SPAGHETTI', 'TACOS', 'BURRITO', 'SALAD', 'BUREK', 'CHICKEN', 'STEAK', 'SOUP', 'PASTA', 'SANDWICH','RAMEN']
,['FOOTBALL','BASKETBALL','TENNIS','SWIMMING', 'VOLLEYBALL', 'BASEBALL', 'GOLF', 'RUGBY', 'KICKBOX', 'GYMNASTICS', 'MMA', 'SAILING', 'SKIING', 'JUDO','ARCHERY']]

score=0
file_name="highscores.txt"

def Score(file_name):
  with open(file_name, 'r') as file:
    print(file.read())
  time.sleep(5)

def SaveScore(file_name, name, score):
    if not os.path.exists(file_name):
        with open(file_name, 'w') as file:
            file.write("=== High Scores ===\n") 
    
    scores = []
    with open(file_name, 'r') as file:
        lines = file.readlines()
        for line in lines[1:]:  
            line = line.strip()
            if line:
                entry_name, entry_score = line.rsplit(' - ', 1)
                scores.append((entry_name, int(entry_score)))
    
    scores.append((name, score))
    
    scores.sort(key=lambda x: x[1], reverse=True)
    
    with open(file_name, 'w') as file:
        file.write("=== High Scores ===\n") 
        for idx, (entry_name, entry_score) in enumerate(scores, start=1):
            file.write(f"{idx}. {entry_name} - {entry_score}\n")

def AskScore():
  answer=input("Do you want to save the score?(Y/N):")
  if(answer=='Y' or answer=='y'):
    name=input("Write your name:")
    SaveScore(file_name,name,score)
  elif(answer=='N' or answer=='n'):
    pass
  else:
    print("You enter the wrong letter!")

def GuessWord(word):
  guessedLetters=[]
  guess=" "
  IsGuessed=False
  numberOfGuess=0
  global score
  for letter in word:
    guess=guess+"_ "
  while not(IsGuessed):
    print(f"{HANGMANPICS[numberOfGuess]}")
    print(f"{guess}")
    print(f"Attempts left: {6-numberOfGuess}")
    print(f"Guessed letters: {guessedLetters}")
    letter=input("Please make the guess:")
    while not(letter.isalpha()):
      letter=input("Invalid input! Please enter the valid input:")
    guessedLetters.append(letter)
    if(word.find(letter.upper())!=-1):
      index=word.find(letter.upper())
      while (word[index:].find(letter.upper())!=-1):
        if(word[index]==letter.upper()):
          newIndex=2*index+1
          guess=guess[:newIndex]+letter.upper()+guess[newIndex+1:]
        index=index+1
    else:
      numberOfGuess=numberOfGuess+1
    if(guess.find('_')==-1):
      IsGuessed=True
      print("|========================================|")
      print(f"You can guess your word.\nIt is {guess}")
      score+=(10-numberOfGuess)
      time.sleep(2)
      return True

    if(numberOfGuess>5):
      IsGuessed=True
      print(f"{HANGMANPICS[numberOfGuess]}")
      print("You are the loser!")
      print(f"The correct word is:{word}")
      return False

def Process(number):
  num=int(number)
  array=copyWords[num-1]
  copyWords.pop(num-1)
  while True:
    if(len(array)==0):
      print("You guess all words")
      return True
    else:
      randomIndex=randint(0,len(array)-1)
      randomWord=array[randomIndex]
      array.pop(randomIndex)
      IsGoing=GuessWord(randomWord)
      if IsGoing==False:
        print(f"Your score:{score}")
        time.sleep(2)
        AskScore()
        return False
  
def StartGame():
  wrongWord=True
  while len(copyCategories)!=0 and wrongWord==True:
    print("Choose the category for guess:")
    for i in range(0,len(copyCategories)):
      print(f"{i+1}.{copyCategories[i]}")
    add=input("Write the number to select the category:")
    copyCategories.pop(int(add)-1)
    wrongWord=Process(add)

def game():
  os.system('cls')
  global score
  global copyCategories
  global copyWords
  ad='0'
  while ad!='3':
    print("1.Start Game")
    print("2.Score")
    print("3.Exit")
    ad=input("Write the number to enter:")
    while not(ad.isdigit()):
      ad=input("Invalid input! Please enter the valid input:")
    if ad=='1':
      score=0
      copyCategories=copy.copy(categories)
      copyWords=copy.deepcopy(words)
      StartGame()
    elif ad=='2':
      Score(file_name)
    elif ad=='3':
      exit()
    else:
      print("You typed a wrong number please, try again!")
    print("----------Welcome back to the lobby!----------")

print("----------Hello and welcome to the Hangman!----------")
game()