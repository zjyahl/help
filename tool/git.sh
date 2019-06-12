git config --global user.name "Your Name"
git config --global user.email "email@example.com"
git init

git status

git diff
git diff –cached
git diff HEAD -- file

git log
git log --pretty=oneline
git reflog
git reset --hard 3628164

git add file2.txt file3.txt
git add -A
git rm test.txt
git reset HEAD readme.txt
git commit -m "wrote a readme file"


git checkout -- readme.txt


git log
git log --pretty=oneline
git show id
git reflog
git reset --hard 3628164
git diff HEAD -- readme.txt 
git checkout -- readme.txt
git reset HEAD readme.txt

ssh-keygen -t rsa -C "youremail@example.com"

git remote add origin git@github.com:michaelliao/learngit.git
git push -u origin master
git push origin master
git push

git clone git@github.com:michaelliao/gitskills.git
env GIT_SSL_NO_VERIFY=true git clone https://github.com

git pull 
git pull –rebase

git checkout -b dev
git branch dev
git checkout dev

git branch
git checkout master
git merge dev
git branch -d dev

git log --graph --pretty=oneline --abbrev-commit
git merge --no-ff -m "merge with no-ff" dev
git rebase origin

git stash
git stash list

git stash apply
git stash drop

git stash pop

git branch -D feature-vulcan

git remote
git remote -v

git push origin master
git push origin dev

git checkout -b dev origin/dev

git branch --set-upstream dev origin/dev

git add -u 
git rebase --continue
git rebase --abort

git add -u：将文件的修改、文件的删除，添加到暂存区。
git add .：将文件的修改，文件的新建，添加到暂存区。
git add -A：将文件的修改，文件的删除，文件的新建，添加到暂存区。
git config --global core.autocrlf true

git rebase 
while(存在冲突) {
    git status
    找到当前冲突文件，编辑解决冲突
    git add -u
    git rebase --continue
    if( git rebase --abort )
        break; 
}

git tag v1.0
git tag v0.9 6224937
git tag -a v0.1 -m "version 0.1 released" 3628164

.gitignore

git diff 

git diff --cached 
git diff --staged 
git diff head

git checkout -- [文件名]

git reset --hard HEAD 再git checkout -- [文件名]

git reset --hard HEAD^或 git reset --hard [版本号]

git fetch orgin master //将远程仓库的master分支下载到本地当前branch中
git log -p master  ..origin/master //比较本地的master分支和origin/master分支的差别
git merge origin/master //进行合并

git fetch origin master:tmp //从远程仓库master分支获取最新，在本地建立tmp分支
git diff tmp //將當前分支和tmp進行對比
git merge tmp //合并tmp分支到当前分支