# Football Web Site

This is an open soure web site developed for local football clubs. The project started few years ago, when I needed to learn Angular 2. I was looking for a simple project is order to practice. At that time, I was playing for the FC Uffheim footabll team and therefore decided to create a website.

## Multi tenant

Currently this website is provided for two different clubs. In order to build it for the correct club, you need to set the correct configuration
ng build --configuration=fcb --buildOptimizer=true
ng build --configuration=fcu
http-server dist

git push origin master

## Docker deployment

In order to deploy the web site, I'm using docker. The following steps has to be done.

### Create the image

docker build --rm -f "Dockerfile" -t test .
--file , -f Name of the Dockerfile (Default is ‘PATH/Dockerfile’)
--rm true Remove intermediate containers after a successful build

### Test the image

- Run the image on 8080
  docker run --rm -it -p 8080:80/tcp test:latest

### Tag the image

Change the id with the correct image id

- docker tag 15704c75083f maxcl10/football-web-site:test

### Push the image in the reporsitory

- docker push maxcl10/football-web-site:test

### Deploy to azure

### Todos

- Fix service workiner issue (workarrounf in main.ts)
- Add Pictures for organizational chart
- move app env to normal env.

- fix FB integration => check if sharing os working
- move guard in core or shared?
- improve toogle dashboard button
- get ride of moment locale in vendor
- Use bootstrap 4
- use following code to set the title
  ngOnInit() {
  if (document.getElementById('pagetitle')) {
  document.getElementById('pagetitle').innerHTML = '<h2>Addresses & Contacts</h2>';
  }

* player details (shared)
* article details (shared)
* game details (shared)
* sponsor details (shared)
* teams details (shared)
* extract article list from home component
* Article in container + button style
* edit stat buttons

### Done

- delete player
- make direct link work
- move service to shared? No because service must be under Core or at component level
- Use caching services to avoid serive calls
- Improve admin navigation
- use route guard for securing the admin part
- Get Next Game must return the next game if today
- set back footer
- add cup assist in DB and UI
- improve page header in xs
- Improve games method performance
- merge new with edit/0 (article, game, player, sponsors)
- fix delete popup background issue (article, player, game, sponsor)

# Tiny MCE

maxime.matter@hotmail.fr
Key x6kya91fxd4udiq2afldv6hr7u1oseggp245bsyzbtpysjey

### Pricing

docker container
service app
DB => free
