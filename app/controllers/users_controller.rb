class UsersController < ApplicationController
  respond_to :json

  def createUser
    @user = User.Insert(params[:Login],params[:Password])
    json_return(@user)
  end

  def getUser
    @user = User.Get(params[:Login],params[:Password])
    json_return(@user)
  end

  def updateProfile
    User.UpdateProfile(params[:Login],params[:Email],params[:FirstName],
                params[:LastName],params[:ProfileImgPath],params[:Facebook],
                params[:Age],params[:Sex],params[:IsPrivate])
    @user = User.find(params[:Login])
    json_return(@user)
  end

  def changeLogin
    User.UpdateLogin(params[:Login],params[:Password],params[:New_login])
    @user = User.Get(params[:New_login],params[:Password])
    json_return(@user)
  end

  def changePassword
    User.UpdatePassword(params[:Login],params[:Password],params[:New_password])
    @user = User.Get(params[:Login],params[:New_password])
    json_return(@user)  
  end

  def deleteUser
    @user = User.Delete(params[:Login],params[:Password])
    json_return(@user)
  end

  def searchByName
    @user = User.SearchUsersByName(params[:Username])
    json_return(@user)
  end

  def json_return(param)
    render json: param
  end

end
