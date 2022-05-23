#!/bin/sh

branch="$(git rev-parse --abbrev-ref HEAD)"

if [ "$branch" = "main" ]; then
  echo "Do not commit in $branch branch! If you're 100% sure, rename .git/hooks/pre-commit.sh "
  exit 1
fi