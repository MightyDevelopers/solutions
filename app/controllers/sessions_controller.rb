class SessionsController < ApplicationController

  def new
      
  end

  def create
    user = User.find_by_Login(params[:Login])
    if user && user.authenticate(params[:Password])
        sign_in user
        render json: user
    else
        render json: ["Invalid email/password combination"]
    end
  end

  def destroy
    sign_out
    render json: ["End of session"]
  end


end
