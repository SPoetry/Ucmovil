<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class PonderacionesRamo extends Model
{
  protected $fillable = [
      'id_ramoimpartido', 'N_nota', 'P_nota',
  ];
}
