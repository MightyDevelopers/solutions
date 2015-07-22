class User < ActiveRecord::Base
  scope :Get, lambda { |login, password| 
   select(:Email, :FirstName, :LastName, :ProfileImgPath, :Facebook, :Age, :Sex, 
    :IsPrivate).
  where(:Login => login , :Password => password ).first }

  scope :Insert, lambda { |login, password| 
    create(:Login => login, :Password => password) }

  scope :UpdatePassword, lambda { |login, password, new_password|
    where(:Login => login, :Password => password).update_all(Password: new_password) }  
  
  scope :UpdateLogin, lambda { |login, password, new_login|
    where(:Login => login, 
          :Password => password).update_all(Login: new_login) }  
  
  scope :Delete, lambda { |login, password|
    delete_all(:Login => login, :Password => password) }

  scope :UpdateProfile, lambda { |login, email, firstName,lastName, profileImgPath, facebook, age, sex, isPrivate|
    where(:Login => login).update_all(Email: email,
    FirstName: firstName, LastName: lastName, 
    ProfileImgPath: profileImgPath, Facebook: facebook, Age: age,
    Sex: sex, IsPrivate: isPrivate ) }

  scope :SearchUsersByName, lambda { |username|
    select(:Email, :FirstName, :LastName, :ProfileImgPath, 
           :Facebook, :Age, :Sex, :IsPrivate).
    where("FirstName LIKE ? OR LastName LIKE ? OR CONCAT (FirstName,' ', LastName) LIKE ? ",
      "%#{username}%","%#{username}%","%#{username}%") }
  
end
