**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
Select * from users where id in (3,2,4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
MYSQL
select first_name,last_name,COUNT(IF(l.STATUS = 2, l.STATUS, NULL)) AS basic,COUNT(IF(l.STATUS = 3, l.STATUS, NULL)) AS premium from users u join listings l on u.id = l.user_id where u.STATUS = 2 
group by first_name,last_name

SQLSERVER
with dummy as (
select first_name,last_name,l.STATUS from users u join listings l on u.id = l.user_id where u.STATUS = 2)
select first_name,last_name,[2] as basic,[3] as premium from dummy pivot (count(STATUS) for STATUS in ([2],[3]))
as PV


3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium
select * from (select first_name,last_name,COUNT(IF(l.STATUS = 2, l.STATUS, NULL)) AS basic,COUNT(IF(l.STATUS = 3, l.STATUS, NULL)) AS premium from users u join listings l on u.id = l.user_id where u.STATUS = 2 
group by first_name,last_name) as dummy where premium >= 1


4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue
select first_name,last_name,Ifnull(currency,0) as currency,Ifnull(sum(price),0) as revenue from users u 
left join listings l on u.id = l.user_id left join clicks c on c.listing_id = l.id 
and Year(c.created) = '2013' where u.STATUS = 2 group by first_name,last_name,currency order by revenue desc


5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
INSERT INTO `clicks` (listing_id,price) VALUES (3,4.00);SELECT LAST_INSERT_ID();


6. Show listings that have not received a click in 2013
- Please return at least: listing_name
select name as listing_name from listings where id not in(select distinct listing_id from clicks where Year(created) = '2013')


7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
select YEAR(created) as date,count(c.listing_id) as total_listings_clicked,count(distinct l.user_id) as total_vendors_affected from clicks c join listings l 
on c.listing_id = l.id group by YEAR(created) 


8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
select 
    first_name,last_name,GROUP_CONCAT(name)
from
    (select name,first_name,last_name from users u join listings l on u.id = l.user_id where u.STATUS = 2) as Result group by first_name,last_name;
