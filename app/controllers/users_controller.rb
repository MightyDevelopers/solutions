class UsersController < ApplicationController
  respond_to :json

  def new
    @user = User.new
  end

  def create
    @user = User.new(user_params)
    if @user.save
        redirect_to @user
    else render 'new'
    end
  end

  def show
    @user = User.find(params[:id])
    render json: @user
  end

  def update_user
      
  end

  def edit_profile
      
  end

  def change_login
      
  end

  def change_password
      
  end

  private

  def user_params
    params.require(:user).permit(:Login, :Password)
  end

end
