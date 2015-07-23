class UsersController < ApplicationController
  respond_to :json

  def createUser
    @user = User.Insert(params[:Login],params[:Password])
    if @user.valid?
      json_return(@user)
    else 
      json_return(@user.errors.full_messages)  
    end
  end

  def getUser
    @user = User.Get(params[:Login],params[:Password])
    if @user.empty?
      @user = ["Can't find this user"]
      json_return(@user)
    else
      json_return(@user)  
    end
  end

  def updateProfile
    status = User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                                params[:LastName],params[:ProfileImgPath],params[:Facebook],
                                params[:Age],params[:Sex],params[:IsPrivate])
    if status == 1
      @user = User.find(params[:Login])
      json_return(@user)
    else
      @messege = ["Somesing wrong(maybe login is invalid?)"]
      json_return(@messege)
    end
  end

  def changeLogin
    status = User.UpdateLogin(params[:Login],params[:Password],params[:New_login])
    if status == 1 
      @user = User.Get(params[:New_login],params[:Password])
      json_return(@user)    
    else 
      @messege = ["Somesing wrong(maybe login/password/new_login is invalid?)"]    
      json_return(@messege)    
    end
  end

  def changePassword
    status = User.UpdatePassword(params[:Login],params[:Password],params[:New_password])
    if status == 1 
      @user = User.Get(params[:Login],params[:New_password])
      json_return(@user)    
    else 
      @messege = ["Somesing wrong(maybe login/password/new_password is invalid?)"]    
      json_return(@messege)    
    end 
  end

  def deleteUser
    status = User.Delete(params[:Login],params[:Password])
    if status == 1
      @user = ["Deleted"]
      json_return(@user)
    else 
      @messege = ["Somesing wrong(maybe login/password is invalid?)"]
      json_return(@messege)
    end
  end

  def searchByName
    @user = User.SearchUsersByName(params[:Username])
    if @user.empty?
      @messege = ["Can't find users whith this params(FirstName LastName)"]
      json_return(@messege)
    else
      json_return(@user)  
    end
  end

  def json_return(param)
    render json: param
  end

end
