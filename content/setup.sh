#!/bin/bash
echo Setting up your SMBC service...
directory=$PWD
echo Working directory: $directory

echo STEP 1 : initialising git...
echo Whats the url of the remote repository?
read repo
git init
git remote add origin $repo

echo STEP 2 : Encrypting secrets...
git-crypt init

echo Whats the relative path to you gpg keystore?
read keystore
cd $keystore

echo STEP 2a : Adding new keys...
git pull
./add-keys.sh

echo STEP 2b : Adding collaborators...
cd $directory
$keystore/add-collaborators.sh

echo STEP 3 : Copying base secrets 
echo Please ensure you have a local unlocked copy of secrets-service-boilerplate repo git@github.com:smbc-digital/secrets-service-boilerplate.git.
echo Whats the relative path to your base secrets repository?
read secrets
cd $secrets
#Update secrets with the latest version
git pull

#copy files
cp -R $secrets/*.json $directory/src/config/secrets
echo Secrets successfully added
cd $directory

echo STEP 4 : Pushing changes...
git add .
git commit -m "SCRIPTED : Initial Commit :rocket:"
git push -u origin master

echo STEP 4 : Run make pipeline, to configre the pipeline creation
