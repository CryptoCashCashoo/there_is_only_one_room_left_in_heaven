SHELL := /bin/bash # This line directly tells the make file to use bash syntax.


all:
	echo "make install <- Main installation ..."
	echo "refresh_main_and_clean_old_branches <- Delete branches and switch to main."

	echo "run make -s .......................to surpress nafty raw echo commands"

install:
	# sign
	git config user.name "CryptoCashCashoo"
	git config user.email cryptocashcashoo@gmail.com

	# BLOCK COMMITS TO MAIN 
	cp pre-commit.sh .git/hooks/pre-commit
	chmod +x .git/hooks/pre-commit

check_old_branches:
	git fetch --prune
	git checkout -q main && git pull
	git checkout -q main && git for-each-ref refs/heads/ "--format=%(refname:short)" | while read branch; do mergeBase=$$(git merge-base main $$branch) && [[ $$(git cherry main $$(git commit-tree $$(git rev-parse $$branch^{tree}) -p $$mergeBase -m _)) == "-"* ]] && echo "$$branch is merged into main and can be deleted";  done


refresh_main_and_clean_old_branches:
	git fetch --prune
	git checkout -q main && git pull
	git checkout -q main && git for-each-ref refs/heads/ "--format=%(refname:short)" | while read branch; do mergeBase=$$(git merge-base main $$branch) && [[ $$(git cherry main $$(git commit-tree $$(git rev-parse $$branch^{tree}) -p $$mergeBase -m _)) == "-"* ]] && git branch -D $$branch; done
	