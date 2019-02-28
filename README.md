#TODO

In shell.py line 123:

```
def writeFile( location, fileName, fileContents):
    absPath = os.path.abspath(location + '/' + fileName).strip()

    # print absPath
    #wb to output LF, w outputs CRLF
    with open(absPath, 'wb') as outfile: ---> Error line
```

check if `tempLocation` dir exist otherwise create it. Currently, the above code will throw exception.



