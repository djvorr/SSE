import random
import time

#building percentage
b = 4 # 25%
#object percentage
o = 50 # 2.5%

#number of desired objects
n = 8

#format output
form = False

#i = input('Number of frames to Generate: ')
i = input()
w = 0

if i.isdigit() == False:
	i = 50
	w = 50
else:
	i = int(i)
	w = int(input('Width of frame: '))

def drawFrame():
	generateObjects()
	generateBuildings()
	printFrame(form)

def getRand(a, b):
	r = random.randint(a,b)
	return r
	
def initFrame():
	f = []
	for x in range(w):
		ff = []
		for x in range(w):
			ff.append(0);
		f.append(ff)
	return f 
	
def generateObjects():
	numObj = 0
	for y in range(thresh):
		for x in range(w):
			if flip() and numObj < n:
				if buildObject(y, x) == False:
					numObj += 1
					y += 4

def buildObject(y, x):
	failed = True
	if frame[y][x] == 0:
		for a in range (ow):
			for b in range(ow):
				try:
					frame[y+a][x+b] = 1
					failed = False
				except:
					pass
	return failed
			
def flip(buildings=False):
	if buildings:
		return getRand(1, 100) % b == 0
	else:
		return getRand(1, 100) % o == 0
			
def generateBuildings():
	for x in range(w):
		if flip(True):
			buildBuilding(x)
			
def buildBuilding(x):
	h = getRand(1, int(w/2))
	for z in range(ow):
		for y in range(1,h+1):
			try:
				frame[w-y][x+z] = 1
			except:
				pass

def printFrame(format=False):
	print()
	if format:
		for y in frame:
			l = ''
			for x in y:
				if x == 0:
					l += ' '
				else:
					l += str(x)
			print(l)
		print('__________________________________________________')
	else:
		for x in frame:
			print(x)
		
thresh = int(w * 0.55)
ow = int(w * 0.15)

frame = initFrame()

for x in range(i):
	frame = initFrame()
	drawFrame()
